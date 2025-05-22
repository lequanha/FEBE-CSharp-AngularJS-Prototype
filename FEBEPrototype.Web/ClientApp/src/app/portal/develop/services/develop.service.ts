import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

import { IComponent } from '../models/component.type';
import { IProject } from '../models/project.type';
import { IProjectType } from '../models/project-type.type';

@Injectable(
    { providedIn: 'root' }
)
export class DevelopService {

    constructor(private http: HttpClient) {
    }

    getProjectTypes(): Observable<IProjectType[]> {
        return this.http.get<IProjectType[]>('/api/projecttypes').pipe(take(1));
    }

    getComponents(): Observable<IComponent[]> {
        return this.http.get<IComponent[]>('/api/components').pipe(take(1));
    }

    createProject(project: IProject): Observable<IProject> {
        return this.http.post<IProject>('/api/projects', project);
    }
}
