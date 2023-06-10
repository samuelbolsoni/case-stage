using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.ProccessFeatures.Commands
{
    public class CreateProccessCommand : IRequest<int>
    {
        public int? IdParent { get; set; }
        public int? AreaId { get; set; }
        public string Description { get; set; }
        public string Documentation { get; set; }
        public bool Active { get; set; }
        public List<Person> Persons { get; set; }
        public List<SystemApp> SystemApps { get; set; }
        public List<ProccessFile> Files { get; set; }

        public class CreateProccessCommandHandler : IRequestHandler<CreateProccessCommand, int>
        {
            private readonly IProccessRepository _proccessRepository;
            private readonly IAreaRepository _areaRepository;
            public CreateProccessCommandHandler(IProccessRepository proccessRepository, IAreaRepository areaRepository)
            {
                _proccessRepository = proccessRepository;
                _areaRepository = areaRepository;
            }
            public async Task<int> Handle(CreateProccessCommand command, CancellationToken cancellationToken)
            {
                
                //Valida se area foi informada (em caso de não ter processo pai)
                if (command.AreaId != 0)
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

                var proccess = new Proccess()
                {
                    IdParent = command.IdParent,
                    AreaId = command.AreaId == 0 ? null : command.AreaId,
                    Description = command.Description,
                    Documentation = command.Documentation,
                    Active = command.Active,
                };

                var result = _proccessRepository.Create(proccess);

                if (proccess.Id == 0 || result.IsFaulted)
                    throw new Exception("Erro ao salvar proccesso no banco de dados");

                if (command.Persons.Any())
                {
                    List<ProccessPerson> proccessPersonToAdd = new List<ProccessPerson>();

                    foreach (var person in command.Persons)
                    {
                        proccessPersonToAdd.Add(new ProccessPerson()
                        {
                            PersonId = person.Id,
                            ProccessId = proccess.Id
                        });
                    }
                    await _proccessRepository.CreateProccessPerson(proccessPersonToAdd);
                }

                if (command.SystemApps.Any())
                {
                    List<ProccessSystem> proccessSystemToAdd = new List<ProccessSystem>();

                    foreach (var systemApp in command.SystemApps)
                    {
                        proccessSystemToAdd.Add(new ProccessSystem()
                        {
                            SystemId = systemApp.Id,
                            ProccessId = proccess.Id
                        });
                    }
                    await _proccessRepository.CreateProccessSystemApp(proccessSystemToAdd);
                }

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

                return proccess.Id;
            }
        }
    }
}
