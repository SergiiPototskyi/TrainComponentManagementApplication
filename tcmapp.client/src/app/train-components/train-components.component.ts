import { Component, OnInit } from '@angular/core';
import { TrainComponent } from '../common/models/TrainComponent';
import { HttpParams } from '@angular/common/http';
import { TableLazyLoadEvent } from 'primeng/table';
import { PaginatedList } from '../common/models/PaginatedList';
import { ConfirmationService } from 'primeng/api';
import { NotificationService } from '../common/services/notification.service';
import { HttpClientService } from '../common/services/http-client.service';

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

  displayAddDialog: boolean = false;
  displayEditDialog: boolean = false;
  trainComponendId!: number;

  constructor(
    private httpService: HttpClientService,
    private confirmationService: ConfirmationService,
    private notificationService: NotificationService) {
  }

  ngOnInit(): void {
  }

  getTrainComponents() {
    this.isLoading = true;

    this.httpService.get<PaginatedList>('/api/train-components', this.getParams()).subscribe({
      next: (result) => {
        this.totalRecords = result.totalCount;
        this.trainComponents = result.data;
        this.isLoading = false;
      },
      error: _ => this.isLoading = false
    });
  }

  getParams() {
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
    return params;
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
    this.confirmationService.confirm({
      message: 'Do you really want to delete train component?',
      header: 'Confirmation',
      icon: 'pi pi-exclamation-triangle',
      acceptIcon: "none",
      rejectIcon: "none",
      rejectButtonStyleClass: "p-button-text",
      accept: () => {
        this.httpService.delete('/api/train-components/' + id)
          .subscribe({
            next: _ => {
              this.notificationService.showSuccess('Train component has been deleted');
              this.trainComponents = this.trainComponents.filter(tc => tc.id !== id);
            }
          });
      }
    });
  }

  onEditClick(id: number) {
    this.trainComponendId = id;
    this.displayEditDialog = true;
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

  onAddClick() {
    this.displayAddDialog = true;
  }

  closeAddDialog() {
    this.displayAddDialog = false;
  }

  onTrainComponentAdded(trainComponent: TrainComponent) {
    this.trainComponents.push(trainComponent);
    this.closeAddDialog();
  }

  closeEditDialog() {
    this.displayEditDialog = false;
  }

  onTrainComponentUpdated(updatedComponent: TrainComponent) {
    const index = this.trainComponents.findIndex(tc => tc.id === updatedComponent.id);

    if (index !== -1) {
      this.trainComponents[index] = { ...updatedComponent };
    }
  
    this.closeEditDialog();
  }
}
