import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import {MatExpansionModule} from '@angular/material/expansion';

@Component({
  selector: 'app-home',
  imports: [
    CommonModule,
    MatIconModule,
    MatSnackBarModule,
    MatExpansionModule
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  queryCommand!: Promise<any>;

  readonly dialog = inject(MatDialog);
  constructor(
  ) {

  }

  ngOnInit() {
   
  }
}
