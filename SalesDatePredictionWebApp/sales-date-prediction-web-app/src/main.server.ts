import { bootstrapApplication } from '@angular/platform-browser'
import { AppComponent } from './app/app.component'
import { config } from './app/app.config.server'

const bootstrap = async (): Promise<any> => {
  return await bootstrapApplication(AppComponent, config)
}

export default bootstrap
