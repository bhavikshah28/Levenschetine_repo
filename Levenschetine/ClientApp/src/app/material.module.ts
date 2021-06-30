import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatMenuModule} from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
   imports: [
      CommonModule,
      MatButtonModule,
      MatFormFieldModule,
      MatInputModule,
      MatTooltipModule,
      MatMenuModule,
      MatIconModule,
   ],
   exports: [
      MatButtonModule,
      MatInputModule,
      MatFormFieldModule,
      MatTooltipModule,
      MatMenuModule,
      MatIconModule,
   ],
   providers: []
})

export class AngularMaterialModule { }