import {Product} from './product';

export class ProductPageResult {
  constructor(
    public total_count: number,
    public items: Product[],
  ) {

  }
}
