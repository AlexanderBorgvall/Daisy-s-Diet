import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
})
export class FrontPageComponent {
  constructor(private authService: AuthService, private router: Router) {}

  showEmployeePage(): void {
    this.navigateTo('employee');
  }

  private navigateTo(target: string): void {
    this.authService.authenticate('username', 'password').subscribe(isAuth => {
      if (!isAuth) {
        this.router.navigate(['login'], { queryParams: { redirect: target } });
      } else {
        this.router.navigate([target]);
      }
    });
  }
}
