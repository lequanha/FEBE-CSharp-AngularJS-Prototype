import { IComponent } from "./component.type";

export interface IProject {
    name: string;
    description: string;
    componentIds: Array<number>;
    tags: Array<string>;
}
