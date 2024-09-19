import { HttpInterceptorFn, HttpResponse } from '@angular/common/http'
import { tap } from 'rxjs/operators'
import { inject } from '@angular/core'
import { MessageService } from 'primeng/api'

export const HttpSuccessInterceptor: HttpInterceptorFn = (req, next) => {
  const messageService = inject(MessageService)

  return next(req).pipe(
    tap(event => {
      if (event instanceof HttpResponse) {
        switch (event.status) {
          case 200:
            // Success
            break
          case 201:
            messageService.add({
              severity: 'success',
              summary: '',
              detail: 'Creado exitosamente'
            })
            break
          case 202:
            messageService.add({
              severity: 'success',
              summary: '',
              detail: 'Aceptado exitosamente'
            })
            break
          default:
            // default
            break
        }
      }
    })
  )
}
