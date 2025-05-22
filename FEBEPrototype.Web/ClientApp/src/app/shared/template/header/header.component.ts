import { Component, OnInit } from '@angular/core';

import { ThemeConstantService } from '../../services/theme-constant.service';

@Component({
    selector: 'dh-header',
    templateUrl: './header.component.html'
})

export class HeaderComponent implements OnInit {

    searchVisible = false;
    quickViewVisible = false;
    isFolded: boolean;
    isExpand: boolean;

    constructor(private themeService: ThemeConstantService) { }

    ngOnInit(): void {
        this.themeService.isMenuFoldedChanges.subscribe(isFolded => this.isFolded = isFolded);
        this.themeService.isExpandChanges.subscribe(isExpand => this.isExpand = isExpand);
    }

    toggleFold() {
        this.isFolded = !this.isFolded;
        this.themeService.toggleFold(this.isFolded);
    }

    toggleExpand() {
        this.isFolded = false;
        this.isExpand = !this.isExpand;
        this.themeService.toggleExpand(this.isExpand);
        this.themeService.toggleFold(this.isFolded);
    }

    searchToggle(): void {
        this.searchVisible = !this.searchVisible;
    }

    quickViewToggle(): void {
        this.quickViewVisible = !this.quickViewVisible;
    }

}
