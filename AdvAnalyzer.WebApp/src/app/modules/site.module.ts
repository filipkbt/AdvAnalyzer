import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../core/guards/auth.guard';


export const routes: Routes = [
    {
        path: 'auth',
        loadChildren: () =>
            import('./auth/auth.module').then(
                (m) => m.AuthModule
            ),
    },
    {
        path: 'advertisement',
        loadChildren: () =>
            import('./advertisement/advertisement.module').then(
                (m) => m.AdvertisementModule
            ),
        canActivate: [AuthGuard]
    }
];

@NgModule({
    declarations: [],
    imports: [CommonModule, RouterModule.forChild(routes)],
})
export class SiteModule { }
