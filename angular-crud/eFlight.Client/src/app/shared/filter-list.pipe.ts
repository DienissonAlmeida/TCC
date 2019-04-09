import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "filterList"
})
export class FilterListPipe implements PipeTransform {
  transform(values: any[], filter: string): any {

    if (filter !== "") {
      console.log(filter);
      return values.filter(item =>
        item.city.search(new RegExp(filter, "i")) !== -1);
    } else {
      return values;
    }
  }
}
