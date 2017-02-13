import { Injectable } from '@angular/core';
//import { Http, Headers, Response } from '@angular/http';
import { Observable } from "RxJS/Rx";
import { Router } from '@angular/router';
import { HttpService } from '../../_services/http.service';

export interface BadgeItem {
  type: string;
  value: string;
}

export interface ChildrenItems {
  state: string;
  name: string;
  type?: string;
}

export interface Menu {
  state: string;
  name: string;
  type: string;
  icon: string;
  badge?: BadgeItem[];
  children?: ChildrenItems[];
}

const MENUITEMS = [
  {
    state: 'home',
    name: 'OrdersMonitor',
    type: 'link',
    icon: 'explore'
  }
  // ,
  // {
  //   state: 'apps',
  //   name: 'APPS',
  //   type: 'sub',
  //   icon: 'apps',
  //   badge: [
  //     {type: 'red', value: '5'}
  //   ],
  //   children: [
  //     {state: 'calendar', name: 'CALENDAR'},
  //     {state: 'media', name: 'MEDIA'},
  //     {state: 'messages', name: 'MESSAGES'},
  //     {state: 'social', name: 'SOCIAL'},
  //     {state: 'chat', name: 'CHAT'}
  //   ]
  // },
  // {
  //   state: 'widgets',
  //   name: 'WIDGETS',
  //   type: 'link',
  //   icon: 'photo'
  // },
  // {
  //   state: 'material',
  //   name: 'MATERIAL',
  //   type: 'sub',
  //   icon: 'equalizer',
  //   badge: [
  //     {type: 'purple', value: '10'}
  //   ],
  //   children: [
  //     {state: 'button', name: 'BUTTON'},
  //     {state: 'cards', name: 'CARDS'},
  //     {state: 'select', name: 'SELECT'},
  //     {state: 'input', name: 'INPUT'},
  //     {state: 'checkbox', name: 'CHECKBOX'},
  //     {state: 'radio', name: 'RADIO'},
  //     {state: 'toolbar', name: 'TOOLBAR'},
  //     {state: 'lists', name: 'LISTS'},
  //     {state: 'grid', name: 'GRID'},
  //     {state: 'progress', name: 'PROGRESS'},
  //     {state: 'tabs', name: 'TABS'},
  //     {state: 'switch', name: 'SWITCH'},
  //     {state: 'tooltip', name: 'TOOLTIP'},
  //     {state: 'menu', name: 'MENU'},
  //     {state: 'slider', name: 'SLIDER'},
  //     {state: 'snackbar', name: 'SNACKBAR'},
  //     {state: 'dialog', name: 'DIALOG'}
  //   ]
  // },
  // {
  //   state: 'forms',
  //   name: 'FORMS',
  //   type: 'sub',
  //   icon: 'looks_3',
  //   children: [
  //     {state: 'editor', name: 'EDITOR'},
  //     {state: 'validation', name: 'VALIDATION'},
  //     {state: 'upload', name: 'UPLOAD'},
  //     {state: 'tree', name: 'TREE'},
  //   ]
  // },
  // {
  //   state: 'tables',
  //   name: 'TABLES',
  //   type: 'sub',
  //   icon: 'format_line_spacing',
  //   badge: [
  //     {type: 'blue-grey', value: '8'
  //     }
  //   ],
  //   children: [
  //     {state: 'fullscreen', name: 'FULLSCREEN'},
  //     {state: 'editing', name: 'EDITING'},
  //     {state: 'filter', name: 'FILTER'},
  //     {state: 'paging', name: 'PAGING'},
  //     {state: 'sorting', name: 'SORTING'},
  //     {state: 'pinning', name: 'PINNING'},
  //     {state: 'selection', name: 'SELECTION'},
  //   ]
  // },
  // {
  //   state: 'charts',
  //   name: 'CHARTS',
  //   type: 'link',
  //   icon: 'show_chart',
  // },
  // {
  //   state: 'maps',
  //   name: 'MAPS',
  //   type: 'sub',
  //   icon: 'navigation',
  //   badge: [
  //     {type: 'green', value: 'new'
  //     }
  //   ],
  //   children: [
  //     {state: 'google', name: 'GOOGLE'},
  //     {state: 'leaflet', name: 'LEAFLET'}
  //   ]
  // },
  // {
  //   state: 'dragndrop',
  //   name: 'DND',
  //   type: 'link',
  //   icon: 'show_chart',
  // },
  // {
  //   state: 'pages',
  //   name: 'PAGES',
  //   type: 'sub',
  //   icon: 'pages',
  //   children: [
  //     {state: 'invoice', name: 'INVOICE'},
  //     {state: 'timeline', name: 'TIMELINE'},
  //     {state: 'user', name: 'USER'},
  //     {state: 'blank', name: 'BLANK'},
  //   ]
  // },
  // {
  //   state: 'session',
  //   name: 'SESSION',
  //   type: 'sub',
  //   icon: 'face',
  //   children: [
  //       { state: '404', name: '404', icon: 'face'},
  //     {state: 'error', name: 'ERROR'},
  //     {state: 'signin', name: 'SIGNIN'},
  //     {state: 'signup', name: 'SIGNUP'},
  //     {state: 'forgot', name: 'FORGOT'},
  //     {state: 'lockscreen', name: 'LOCKSCREEN'},
  //   ]
  // },
  // {
  //   state: 'http://primer.nyasha.me/docs',
  //   name: 'DOCS',
  //   type: 'extTabLink',
  //   icon: 'local_library'
  // }
];

@Injectable()
export class MenuItems {
    public menuObj: Menu[]; 
    private apiUrl: string = 'http://promanagerapi.leadersoft.gr/';
    constructor(private router: Router, private http: HttpService) { }

    getMenu(): void  {

        // for  testing
      this.menuObj = MENUITEMS;

        //!!!!!!!! UNCOMMENT to get menu from SERVER
		// this.http.get(this.apiUrl + 'api/Menus/Getall')
		//     .map(response => response.json().Data)           
		//     .subscribe((json: Menu[]) => {
		//         if (json && json.length > 0) {
		//             console.log("GOT MENU " + JSON.stringify(json));
		//             this.menuObj = json;
		//         }
		//         else
		//             this.router.navigate(['./session/error']);
		//     },
		//     function (error) {
		//         console.log("ERROR GETTING MENU " + error);
		//         this.router.navigate(['./session/error']);
		//     }
		    //);
  }

  add(menu: Menu) {
     this.menuObj.push(menu);
  }


}
