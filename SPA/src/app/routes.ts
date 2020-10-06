import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {RequestsComponent} from './requests/requests.component';
import {ActionsComponent} from './actions-list/actions/actions.component';
import {AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    {path: '' , component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'requests' , component: RequestsComponent},
            {path: 'actions' , component: ActionsComponent},
        ]
    },

    {path: '**' , redirectTo: '' , pathMatch: 'full'},

];
