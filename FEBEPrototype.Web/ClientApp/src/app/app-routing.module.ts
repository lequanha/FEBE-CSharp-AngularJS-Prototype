import { NgModule } from '@angular/core';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';


const AdminRoutes: Routes = [
    {
        path: 'portal',
        canActivate: [AuthorizeGuard],
        children: [
            {
                path: 'dashboard',
                loadChildren: () => import('./portal/dashboard/dashboard-routing.module').then(m => m.DashboardRoutingModule)
            },
            {
                path: 'develop',
                loadChildren: () => import('./portal/develop/develop.module').then(m => m.DevelopModule)
            },
            {
                path: '**',
                redirectTo: '/portal/dashboard',
                pathMatch: 'full'
            }
        ]
    },
    {
        path: '**',
        redirectTo: '/portal',
        pathMatch: 'full'
    }
];



const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/portal/dashboard',
        pathMatch: 'full'
    },
    {
        path: '',
        component: AdminLayoutComponent,
        children: AdminRoutes
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes, {
            preloadingStrategy: PreloadAllModules,
            anchorScrolling: 'enabled',
            scrollPositionRestoration: 'enabled'
        })
    ],
    exports: [
        RouterModule
    ]
})

export class AppRoutingModule {
}