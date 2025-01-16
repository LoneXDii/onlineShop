import {inject} from '@angular/core';
import {AuthService} from '../services/auth.service';
import {Router} from '@angular/router';

export const canActivateAuth = () =>{
  const isLoggedIn = inject(AuthService).isAuthenticated;

  if (isLoggedIn){
    return true;
  }

  return inject(Router).createUrlTree(['/login']);
}
