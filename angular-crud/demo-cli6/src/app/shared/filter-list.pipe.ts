import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterList'
})
export class FilterListPipe implements PipeTransform {

  transform(values: any[], term: string): any {
    
    return values.filter(item => {
      item.city.search(new RegExp(term, 'i')) !== -1
    });
  }

}
