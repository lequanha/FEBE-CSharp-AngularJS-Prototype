import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzDrawerModule } from 'ng-zorro-antd/drawer';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd';

import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';

import { HeaderComponent } from './header/header.component';

import { ThemeConstantService } from '../services/theme-constant.service';
import { QuickViewComponent } from './quick-view/quick-view.component';
import { FormsModule } from '@angular/forms';
import { SideNavComponent } from './side-nav/side-nav.component';
import { UserMenuComponent } from './header/user-menu.component';
import { NotificationMenuComponent } from './header/notification-menu.component';

const antdModule = [
    NzAvatarModule,
    NzBadgeModule,
    NzRadioModule,
    NzDropDownModule,
    NzListModule,
    NzDrawerModule,
    NzDividerModule,
    NzSwitchModule,
    NzInputModule,
    NzButtonModule,
    NzIconModule
];

@NgModule({
    exports: [
        CommonModule,
        HeaderComponent,
        SideNavComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule,
        PerfectScrollbarModule,
        ...antdModule
    ],
    declarations: [
        HeaderComponent,
        QuickViewComponent,
        SideNavComponent,
        UserMenuComponent,
        NotificationMenuComponent
    ],
    providers: [
        ThemeConstantService
    ]
})

export class TemplateModule { }
