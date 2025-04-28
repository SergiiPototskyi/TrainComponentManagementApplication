import { Component, OnInit } from '@angular/core';
import { TrainComponent } from '../common/models/TrainComponent';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TableLazyLoadEvent } from 'primeng/table';
import { PaginatedList } from '../common/models/PaginatedList';

@Component({
  selector: 'train-components',
  templateUrl: './train-components.component.html',
  styleUrl: './train-components.component.css'
})
export class TrainComponentsComponent implements OnInit {
  public trainComponents: TrainComponent[] = [];
  isLoading: boolean = false;
  skeletonData: any[] | any;
  searchTerm: string | null = null;
  pageSize: number = 10;
  pageNumber: number = 1;
  sortColumn: string = 'id';
  sortOrder: 'asc' | 'desc' = 'asc';
  totalRecords: number = 0;

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
  }

  getTrainComponents() {
    this.isLoading = true;
    let params = new HttpParams();
    if (this.searchTerm != null) {
      params = params.set('search', this.searchTerm);
    }
    if (this.pageSize != null) {
      params = params.set('pageSize', this.pageSize);
    }
    if (this.pageNumber != null) {
      params = params.set('pageNumber', this.pageNumber);
    }
    if (this.sortColumn != null) {
      params = params.set('sortColumn', this.sortColumn);
    }
    if (this.sortOrder != null) {
      params = params.set('sortOrder', this.sortOrder);
    }
    this.http.get<PaginatedList>('/api/train-components', { params }).subscribe({
      next: (result) => {
        this.totalRecords = result.totalCount;
        this.trainComponents = result.data;
        this.isLoading = false;
      },
      error: (error) => {
        console.error(error);
        this.isLoading = false;
      }
    });
  }

  getStatus(canAssignQuantity: boolean) {
    switch (canAssignQuantity) {
      case true:
        return 'success';
      case false:
        return 'secondary';
    }
  }

  getStatusValue(canAssignQuantity: boolean) {
    switch (canAssignQuantity) {
      case true:
        return 'YES';
      case false:
        return 'NO';
    }
  }

  onDeleteClick(id: number) {
    console.log('Delete')
  }

  onEditClick(id: number) {
    console.log('Edit')
  }

  onSearchClick(searchTerm: string) {
    this.searchTerm = searchTerm;
    this.getTrainComponents();
  }

  loadItemsLazy(event: TableLazyLoadEvent) {
    this.pageNumber = (event.first! / event.rows!) + 1;
    this.pageSize = event.rows!;
    this.sortColumn = event.sortField as string;
    this.sortOrder = event.sortOrder == 1 ? 'asc' : 'desc';
    
    this.getTrainComponents();
  }
}
