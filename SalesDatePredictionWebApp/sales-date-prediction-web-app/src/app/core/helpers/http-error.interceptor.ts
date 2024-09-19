import { HttpErrorResponse, HttpInterceptorFn, HttpResponse } from '@angular/common/http'
import { catchError, of, throwError } from 'rxjs'
import { inject } from '@angular/core'
import { MessageService } from 'primeng/api'
import { Router } from '@angular/router'

export const HttpErrorInterceptor: HttpInterceptorFn = (req, next) => {
  const messageService = inject(MessageService)
  const router = inject(Router)

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      let errorMessage = 'Unknown error'

      if (error.error instanceof ErrorEvent) {
        errorMessage = `Error: ${error.error.message}`
      } else {
        errorMessage = error.error.message ?? 'default_message'

        switch (error.status) {
          case 400:
          case 404:
          case 409:
            messageService.add({
              severity: 'error',
              summary: '',
              detail: `${errorMessage}`
            })
            void router.navigate(['/'], { state: { reload: true } })
            break
          case 401:
            void router.navigate(['/pages/error'], { state: { value: 'The user does not have permissions on this application' } })
            break
          case 500:
            void router.navigate(['/pages/error'], { state: { value: errorMessage } })
            break
          case 0:
            void router.navigate(['/pages/error'], { state: { value: 'Services are not available, contact the administrator' } })
            break
          default:
            return throwError(() => new Error(errorMessage))
        }

        const result = new HttpResponse({
          body: {
            errorCode: error.status,
            errorMessage,
            dateTime: new Date()
          }
        })

        return of(result)
      }

      return throwError(() => new Error(errorMessage))
    })
  )
}
