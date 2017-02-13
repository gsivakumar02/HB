import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Router } from '@angular/router';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule, Http, XHRBackend, RequestOptions} from '@angular/http';

import { TranslateModule, TranslateLoader, TranslateStaticLoader } from 'ng2-translate/ng2-translate';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from "@angular/flex-layout";

import { JazzDialog } from './material/dialog/dialog.component';

import { AppRoutes } from './app.routing';
import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './layouts/admin/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth/auth-layout.component';
import { SharedModule }       from './shared/shared.module';

import { LocalStorageModule } from 'angular-2-local-storage';

import { AuthGuard } from './_guards/index';
import { AuthenticationService } from './_services/index';
import { HttpService } from './_services/http.service';
import { ToastModule, ToastOptions, ToastsManager } from 'ng2-toastr/ng2-toastr';
// import { OrdersMonitorComponent } from './orders-monitor/orders-monitor.component';
export function createTranslateLoader(http: Http) {
  return new TranslateStaticLoader(http, './assets/i18n', '.json');
}

export function createHttpServiceFactory(backend: XHRBackend, options: RequestOptions, route: Router) {
    return new HttpService(backend, options, route);
}




@NgModule({
    declarations: [
        AppComponent,
        AdminLayoutComponent,
        AuthLayoutComponent,
        JazzDialog,
       // OrdersMonitorComponent,
    ],
    imports: [
        BrowserModule,
        ToastModule,
        SharedModule,
        RouterModule.forRoot(AppRoutes),
        FormsModule,
        HttpModule,
        TranslateModule.forRoot({
            provide: TranslateLoader,
            useFactory: (createTranslateLoader),
            deps: [Http]
        }),
        MaterialModule.forRoot(),
        FlexLayoutModule.forRoot(),
        LocalStorageModule.withConfig({
            prefix: 'proManager',
            storageType: 'localStorage'
        })       
    ],
    providers: [AuthGuard, AuthenticationService, ToastsManager,
        {
            provide: HttpService,
            useFactory: createHttpServiceFactory,
            deps: [XHRBackend, RequestOptions, Router]
        }
        
  ],
  entryComponents: [ JazzDialog ],
  bootstrap: [AppComponent]
})
export class AppModule { }
