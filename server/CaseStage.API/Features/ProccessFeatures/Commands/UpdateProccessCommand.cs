using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.ProccessFeatures.Commands
{
    public class UpdateProccessCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int? IdParent { get; set; } = null;
        public int? AreaId { get; set; } = null;
        public string Description { get; set; }
        public string Documentation { get; set; }
        public bool Active { get; set; }
        public List<int>? Persons { get; set; }
        public List<int>? SystemApps { get; set; }
        //public List<ProccessFile>? Files { get; set; }

        public class UpdateProccessCommandHandler : IRequestHandler<UpdateProccessCommand, int>
        {
            private readonly IProccessRepository _proccessRepository;
            private readonly IAreaRepository _areaRepository;

            public UpdateProccessCommandHandler(IProccessRepository proccessRepository, IAreaRepository areaRepository)
            {
                _proccessRepository = proccessRepository;
                _areaRepository = areaRepository;
            }
            public async Task<int> Handle(UpdateProccessCommand command, CancellationToken cancellationToken)
            {
                var proccess = await _proccessRepository.GetProccessById(command.Id);

                if (proccess == null)
                {
                    throw new Exception("Processo não encontrado");
                }
                else
                {
                    //Valida se area foi informada (em caso de não ter processo pai)
                    if (command.AreaId != null)
                    {
                        //Verifica se area informada existe no db
                        Area area = await _areaRepository.GetAreaById(Convert.ToInt32(command.AreaId));

                        if (area == null)
                            throw new Exception("Area informada não existe no banco de dados");

                        // Seta idParent como null (Processo pai)
                        command.IdParent = null;
                    }

                    if (String.IsNullOrEmpty(command.Description))
                        throw new Exception("Descricao nao informada");

                    proccess.AreaId = command.AreaId;
                    proccess.IdParent = command.IdParent == 0 ? null : command.IdParent;
                    proccess.Description = command.Description;
                    proccess.Documentation = command.Documentation;
                    proccess.Active = command.Active;
                    proccess.UpdatedAt = DateTime.Now;

                    //Deleta pessoas, sistemas, files do processo
                    await _proccessRepository.DeleteProccessPersonByProccessId(proccess.Persons);
                    await _proccessRepository.DeleteProccessSystemByProccessId(proccess.Systems);
                    //await _proccessRepository.DeleteProccessFileByProccessId(proccess.Files);

                    var result = _proccessRepository.Update(proccess);

                    if (result.IsFaulted)
                        throw new Exception("Erro ao atualizar proccesso no banco de dados");

                    if (command.Persons.Any())
                    {
                        List<ProccessPerson> proccessPersonToAdd = new List<ProccessPerson>();

                        foreach (var idPerson in command.Persons)
                        {
                            proccessPersonToAdd.Add(new ProccessPerson()
                            {
                                PersonId = idPerson,
                                ProccessId = proccess.Id
                            });
                        }
                        await _proccessRepository.CreateProccessPerson(proccessPersonToAdd);
                    }
                    
                    if (command.SystemApps.Any())
                    {
                        List<ProccessSystem> proccessSystemToAdd = new List<ProccessSystem>();

                        foreach (var idSystemApp in command.SystemApps)
                        {
                            proccessSystemToAdd.Add(new ProccessSystem()
                            {
                                SystemId = idSystemApp,
                                ProccessId = proccess.Id
                            });
                        }
                        await _proccessRepository.CreateProccessSystemApp(proccessSystemToAdd);
                    }
                    
                    /*
                    if (command.Files.Any())
                    {
                        List<ProccessFile> proccessFileToAdd = new List<ProccessFile>();

                        foreach (var file in command.Files)
                        {
                            proccessFileToAdd.Add(new ProccessFile()
                            {
                                Name = file.Name,
                                FileName = file.FileName,
                                ProccessId = proccess.Id
                            });
                        }
                        await _proccessRepository.CreateProccessFile(proccessFileToAdd);
                    }
                    */
                    return proccess.Id;
                }
            }
        }
    }
}
