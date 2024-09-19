export class Pageable {
  page?: number
  size?: number
  sort?: string

  constructor (page?: number, size?: number, sort?: any) {
    this.page = page
    this.size = size
    this.sort = sort
  }
}
