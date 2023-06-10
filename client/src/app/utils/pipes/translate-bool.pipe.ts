import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'translateBool'
})
export class TranslateBoolPipe implements PipeTransform {

  transform(value: any, ...args: unknown[]): any {
    return value ? 'Sim' : 'Não';
  }
}
