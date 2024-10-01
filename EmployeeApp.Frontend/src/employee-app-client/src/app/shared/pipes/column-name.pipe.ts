import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  standalone: true,
  name: 'columnname',
})
export class ColumnNamePipe implements PipeTransform {
  transform(value: string): string {
    return value.replace(/([a-z])([A-Z])/g, '$1 $2').toUpperCase();
  }
}