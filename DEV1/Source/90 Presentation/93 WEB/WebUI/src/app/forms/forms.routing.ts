import { Routes } from "@angular/router";

import { FormUploadComponent } from './form-upload/form-upload.component';
import { FormValidationComponent } from './form-validation/form-validation.component';
import { FormTreeComponent } from './form-tree/form-tree.component';
import { EditorComponent } from './editor/editor.component';
import { Imt103Component } from './incoming/imt103.component';

export const FormRoutes: Routes = [
  {
    path: '',
    children: [{
      path: 'upload',
      component: FormUploadComponent
    }, {
      path: 'validation',
      component: FormValidationComponent
    }, {
      path: 'editor',
      component: EditorComponent
    }, {
      path: 'tree',
      component: FormTreeComponent
    },
    {
      path: 'imt103',
      component: Imt103Component
    }]
  }
];
