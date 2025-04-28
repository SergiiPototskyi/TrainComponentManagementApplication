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

@NgModule({
  declarations: [
    AppComponent,
    TrainComponentsComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule, BrowserAnimationsModule, HttpClientModule,
    AppRoutingModule,
    TableModule, ButtonModule, InputTextModule, SkeletonModule, DataViewModule, TagModule, PaginatorModule,
    InputGroupModule, InputGroupAddonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
