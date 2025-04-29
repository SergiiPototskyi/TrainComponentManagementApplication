import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { SkeletonModule } from 'primeng/skeleton';
import { DataViewModule } from 'primeng/dataview';
import { TrainComponentsComponent } from './train-components/train-components.component';
import { HomeComponent } from './home/home.component';
import { TagModule } from 'primeng/tag';
import { PaginatorModule } from 'primeng/paginator';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { AddTrainComponentComponent } from './add-train-component/add-train-component.component';
import { DialogModule } from 'primeng/dialog';
import { FloatLabelModule } from 'primeng/floatlabel';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CheckboxModule } from 'primeng/checkbox';
import { TooltipModule } from 'primeng/tooltip';
import { InputNumberModule } from 'primeng/inputnumber';
import { EditTrainComponentComponent } from './edit-train-component/edit-train-component.component';

@NgModule({
  declarations: [
    AppComponent,
    TrainComponentsComponent,
    HomeComponent,
    AddTrainComponentComponent,
    EditTrainComponentComponent
  ],
  imports: [
    BrowserModule, BrowserAnimationsModule, HttpClientModule, FormsModule, ReactiveFormsModule,
    AppRoutingModule,
    TableModule, ButtonModule, InputTextModule, SkeletonModule, DataViewModule, TagModule, PaginatorModule,
    InputGroupModule, InputGroupAddonModule, ConfirmDialogModule, ToastModule, DialogModule, FloatLabelModule,
    CheckboxModule, TooltipModule, InputNumberModule
  ],
  providers: [MessageService, ConfirmationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
