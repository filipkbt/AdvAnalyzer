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
    },
    {
        path: 'notification',
        loadChildren: () =>
            import('./notification/notification.module').then(
                (m) => m.NotificationModule
            ),
        canActivate: [AuthGuard]
    },
    {
        path: 'search-query',
        loadChildren: () =>
            import('./search-query/search-query.module').then(
                (m) => m.SearchQueryModule
            ),
        canActivate: [AuthGuard]
    }
];

@NgModule({
    declarations: [],
    imports: [CommonModule, RouterModule.forChild(routes)],
})
export class SiteModule { }
