import { Pageable } from '../core/models/pageable'
import { HttpParams } from '@angular/common/http'

export function buildHttpParamsPageable (pageable?: Pageable): HttpParams {
  let params = new HttpParams()
  if (pageable?.page != null) {
    params = params.set('page', pageable.page)
  }
  if (pageable?.size != null) {
    params = params.set('size', pageable.size)
  }
  if (pageable?.sort != null) {
    params = params.set('sort', pageable.sort)
  }
  return params
}

export function isNullOrUndefined (value: any): boolean {
  return value === null || value === undefined
}
