import { Component, OnInit } from '@angular/core';

import { ROUTES } from './side-nav-routes.config';
import { ThemeConstantService } from '../../services/theme-constant.service';

@Component({
    selector: 'dh-sidenav',
    templateUrl: './side-nav.component.html'
})

export class SideNavComponent implements OnInit {

    public menuItems: any[];
    isFolded: boolean;
    isSideNavDark: boolean;

    constructor(private themeService: ThemeConstantService) { }

    ngOnInit(): void {
        this.menuItems = ROUTES.filter(menuItem => menuItem);
        this.themeService.isMenuFoldedChanges.subscribe(isFolded => this.isFolded = isFolded);
        this.themeService.isSideNavDarkChanges.subscribe(isDark => this.isSideNavDark = isDark);
    }
}
