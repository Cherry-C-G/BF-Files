import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginPage } from './login/login.page';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  /*
  {
    path: '',
    loadChildren: () => import('./tabs/tabs.module').then(m => m.TabsPageModule)
  },
  {
    path: 'splash',
    loadChildren: () => import('./splash/splash.module').then( m => m.SplashPageModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then( m => m.LoginPageModule)
  }
  */
  
  {path:'',canLoad:[AuthGuard],children:[
    {
      path: 'login',
      loadChildren: () => import('./login/login.module').then( m => m.LoginPageModule)
    },
    {
      path: 'splash',
      loadChildren: () => import('./splash/splash.module').then( m => m.SplashPageModule)
    }
  ]}
  

  // redefine our routes
  // we automaticaly going to splash page
  

];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
