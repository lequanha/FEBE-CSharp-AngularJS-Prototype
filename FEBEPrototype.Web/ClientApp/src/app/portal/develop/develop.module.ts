import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {
    NzStepsModule,
    NzCardModule,
    NzRadioModule,
    NzButtonModule,
    NzInputModule,
    NzDividerModule,
    NzIconModule,
    NzTabsModule,
    NzTagModule,
    NzCheckboxModule,
    NzAvatarModule,
    NzFormModule
} from 'ng-zorro-antd';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';

import { DevelopRoutingModule } from './develop-routing.module';
import { CreateProjectComponent } from './components/create-project/create-project.component';
import { ProjectsComponent } from './components/projects/project.component';
import { ManageFilesComponent } from './components/manage-files/manage-files.component';

const antdModule = [
    NzStepsModule,
    NzCardModule,
    NzRadioModule,
    NzButtonModule,
    NzInputModule,
    NzDividerModule,
    NzIconModule,
    NzTabsModule,
    NzTagModule,
    NzCheckboxModule,
    NzAvatarModule,
    NzFormModule
];

@NgModule({
    imports: [
        FormsModule,
        ReactiveFormsModule,
        DevelopRoutingModule,
        PerfectScrollbarModule,
        ...antdModule
    ],
    declarations: [
        CreateProjectComponent,
        ProjectsComponent,
        ManageFilesComponent
    ]
})

export class DevelopModule {

}
