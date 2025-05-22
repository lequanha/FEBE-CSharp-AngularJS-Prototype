import {
    Component,
    ViewChild,
    ElementRef,
    OnInit,
    ChangeDetectionStrategy,
    ChangeDetectorRef
} from '@angular/core';

import { DevelopService } from '../../services/develop.service';
import { IComponent } from '../../models/component.type';
import { IProjectType } from '../../models/project-type.type';
import { combineLatest } from 'rxjs';
import { IProject } from '../../models/project.type';

interface ISelectableComponent extends IComponent {
    selected: boolean;
}


@Component({
    selector: 'dh-creat-project',
    templateUrl: './create-project.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class CreateProjectComponent implements OnInit {

    @ViewChild('tagInput', { static: false }) tagInputEl: ElementRef;

    ready = false;
    components: Array<ISelectableComponent> = [];
    projectTypes: Array<IProjectType> = [];
    selectedProjectType: IProjectType;

    projectInfo: IProject = {
        name: '',
        description: '',
        tags: [],
        componentIds: []
    };

    currentStep = 0;
    tagInputVisible = false;

    constructor(
        private developService: DevelopService,
        private cdRef: ChangeDetectorRef) {
    }

    ngOnInit() {
        combineLatest([
            this.developService.getComponents(),
            this.developService.getProjectTypes()
        ]).subscribe(([c, p]) => {
            this.components = c.map(cmp => Object.assign(cmp, { selected: false }));
            this.projectTypes = p;
            this.selectedProjectType = p[0];
            this.selectProjectType(this.selectedProjectType);
            this.ready = true;
            this.cdRef.markForCheck();
        });
    }

    goNext() {
        if (this.currentStep <= 2) {
            this.currentStep += 1;
        }
    }

    goPrevious() {
        if (this.currentStep > 0) {
            this.currentStep -= 1;
        }
    }

    launch() {
        this.developService.createProject(this.projectInfo).subscribe(x => {
            console.log(x);
        });
    }

    removeTag(removedTag: string) {
        this.projectInfo.tags = this.projectInfo.tags.filter(tag => tag !== removedTag);
    }

    showTagInput() {
        this.tagInputVisible = true;
        setTimeout(() => {
            this.tagInputEl.nativeElement.focus();
        }, 10);
    }

    addTag(tagValue: string) {
        if (tagValue && this.projectInfo.tags.indexOf(tagValue) === -1) {
            this.projectInfo.tags = [...this.projectInfo.tags, tagValue.trim()];
        }
        this.tagInputVisible = false;
    }

    toggleComponentSelection(component: ISelectableComponent) {
        component.selected = !component.selected;
        this.setProjectComponentIds();
    }

    selectProjectType(projectType: IProjectType) {
        this.components.forEach(cmp => {
            cmp.selected = projectType.componentIds.includes(cmp.id);
        });
        this.setProjectComponentIds();
    }

    private setProjectComponentIds() {
        this.projectInfo.componentIds = this.components.filter(cmp => cmp.selected).map(cmp => cmp.id);
    }
}
