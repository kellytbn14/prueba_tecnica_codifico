import {ApplicationConfig, importProvidersFrom} from '@angular/core'
import {provideRouter} from '@angular/router'

import {routes} from './app.routes'
import {BrowserModule, provideClientHydration} from '@angular/platform-browser'
import {provideAnimationsAsync} from '@angular/platform-browser/animations/async'
import {HttpClientModule, provideHttpClient, withInterceptors} from '@angular/common/http'
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import {CommonModule} from '@angular/common'

import {HttpErrorInterceptor} from './core/helpers/http-error.interceptor'
import {MessageService} from 'primeng/api'
import {HttpSuccessInterceptor} from './core/helpers/http-success.interceptor'
import {ReactiveFormsModule} from "@angular/forms";

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideClientHydration(),
    provideAnimationsAsync(),
    BrowserAnimationsModule,
    BrowserModule,
    CommonModule,
    MessageService,
    ReactiveFormsModule,
    provideHttpClient(
      withInterceptors([HttpErrorInterceptor, HttpSuccessInterceptor])
    ),
    importProvidersFrom(HttpClientModule),
  ]
};
