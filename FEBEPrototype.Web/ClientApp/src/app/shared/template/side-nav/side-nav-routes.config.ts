import { SideNavInterface } from '../../interfaces/side-nav.type';

export const ROUTES: SideNavInterface[] = [
    {
        path: '',
        title: 'Develop',
        iconType: 'nzIcon',
        iconTheme: 'outline',
        icon: 'code',
        subMenu: [
            {
                path: '/develop/create-project',
                title: 'Create Project',
                iconType: 'nzIcon',
                icon: 'project',
                iconTheme: 'outline',
                subMenu: []
            },
            {
                path: '/develop/projects',
                title: 'Projects',
                iconType: 'nzIcon',
                icon: 'project',
                iconTheme: 'outline',
                subMenu: []
            },
            {
                path: '/develop/manage-files',
                title: 'Manage Files',
                iconType: 'nzIcon',
                icon: 'file',
                iconTheme: 'outline',
                subMenu: []
            }
        ]
    }
]