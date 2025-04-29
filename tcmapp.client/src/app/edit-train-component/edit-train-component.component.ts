import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TrainComponent } from '../common/models/TrainComponent';
import { NotificationService } from '../common/services/notification.service';
import { HttpClientService } from '../common/services/http-client.service';
import { IntegerValidator } from '../common/validators/IntegerValidator';
import { QuantityRequiredIfCanAssign } from '../common/validators/QuantityRequiredIfCanAssign';

@Component({
  selector: 'edit-train-component',
  templateUrl: './edit-train-component.component.html',
  styleUrl: './edit-train-component.component.css'
})
export class EditTrainComponentComponent implements OnInit {
  @Input() trainComponentId!: number;
  @Output() success = new EventEmitter<TrainComponent>();
  public editItemForm!: FormGroup;
  isLoading: boolean = false;
  trainComponent!: TrainComponent;

  constructor(
    private fb: FormBuilder,
    private notificationService: NotificationService,
    private httpService: HttpClientService) {
  }

  ngOnInit(): void {
    this.fetchTrainComponentData();
  }

  fetchTrainComponentData() {
    this.isLoading = true;
    this.httpService.get<TrainComponent>('/api/train-components/' + this.trainComponentId).subscribe({
      next: (data) => {
        this.trainComponent = data;
        this.isLoading = false;
        this.editItemForm = this.fb.group({
          id: [{ value: this.trainComponent.id, disabled: true }],
          uniqueNumber: [this.trainComponent.uniqueNumber, Validators.required],
          name: [this.trainComponent.name, Validators.required],
          canAssignQuantity: [this.trainComponent.canAssignQuantity],
          quantity: [
            {
              value: this.trainComponent.quantity,
              disabled: !this.trainComponent.canAssignQuantity
            },
            [IntegerValidator, QuantityRequiredIfCanAssign('canAssignQuantity')]]
        });

        this.editItemForm.get('canAssignQuantity')!.valueChanges.subscribe((canAssign: boolean) => {
          const quantityControl = this.editItemForm.get('quantity');
          if (canAssign) {
            quantityControl!.enable();
          } else {
            this.editItemForm.get('quantity')?.setValue(null);
            quantityControl!.disable();
          }
        });
      },
      error: _ => this.isLoading = false
    });
  }

  onSubmit() {
    this.markFormDirty(this.editItemForm);
    if (this.editItemForm.valid) {
      const item = this.editItemForm.getRawValue();

      this.httpService.put<TrainComponent>('/api/train-components/' + this.trainComponent.id, item).subscribe({
        next: (result) => {
          this.notificationService.showSuccess('Train component successfully updated');
          this.success.emit(result);
        }
      });
    } else {
      this.notificationService.showError('Please fill all fields');
    }
  }

  markFormDirty(form: FormGroup) {
    form.markAllAsTouched(); // Позначає всі поля як торкнуті
    Object.values(form.controls).forEach(control => {
      control.markAsDirty(); // Позначає всі як dirty (змінені)
      control.updateValueAndValidity(); // Оновлює стани валідації
    });
  }
}
