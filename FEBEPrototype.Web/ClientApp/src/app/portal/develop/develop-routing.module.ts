import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreateProjectComponent } from './components/create-project/create-project.component';
import { ProjectsComponent } from './components/projects/project.component';
import { ManageFilesComponent } from './components/manage-files/manage-files.component';

const routes: Routes = [
    {
        path: 'create-project',
        component: CreateProjectComponent,
        data: {
            title: 'Create Project',
            headerDisplay: 'none'
        }
    },
    {
        path: 'projects',
        component: ProjectsComponent,
        data: {
            title: 'Projects',
            headerDisplay: 'none'
        }
    },
    {
        path: 'manage-files',
        component: ManageFilesComponent,
        data: {
            title: 'Manage File',
            headerDisplay: 'none'
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class DevelopRoutingModule { }
