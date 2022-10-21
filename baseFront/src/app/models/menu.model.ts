export class MenuModel {
    id: number;
    name: string | null;
    description: string | null;
    icon: string | null;
    datatarget: string | null;
    url: string | null;
    padre: number;
    idStatus: number;
    subMenu: MenuModel[];
    //menuRoles: MenuRole[];
    constructor() {
        this.id = 0;
        this.name = "";
        this.description = "";
        this.icon = "";
        this.datatarget = "";
        this.url = "";
        this.padre = 0;
        this.idStatus = 0;
        this.subMenu = [];
    }
}