import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IntegerValidator } from '../common/validators/IntegerValidator';
import { NotificationService } from '../common/services/notification.service';
import { HttpClientService } from '../common/services/http-client.service';
import { TrainComponent } from '../common/models/TrainComponent';
import { QuantityRequiredIfCanAssign } from '../common/validators/QuantityRequiredIfCanAssign';

@Component({
  selector: 'add-train-component',
  templateUrl: './add-train-component.component.html',
  styleUrl: './add-train-component.component.css'
})
export class AddTrainComponentComponent {
  public addItemForm: FormGroup;
  isLoading: boolean = false;
  @Output() success = new EventEmitter<TrainComponent>();

  constructor(
    private fb: FormBuilder,
    private notificationService: NotificationService,
    private httpService: HttpClientService) {
    this.addItemForm = this.fb.group({
      name: ['', Validators.required],
      uniqueNumber: ['', Validators.required],
      canAssignQuantity: [false, Validators.required],
      quantity: [{ value: null, disabled: true }, [IntegerValidator, QuantityRequiredIfCanAssign('canAssignQuantity')]]
    });

    this.addItemForm.get('canAssignQuantity')!.valueChanges.subscribe((canAssign: boolean) => {
      const quantityControl = this.addItemForm.get('quantity');
      if (canAssign) {
        quantityControl!.enable();
      } else {
        this.addItemForm.get('quantity')?.setValue(null);
        quantityControl!.disable();
      }
    });
  }

  onSubmit() {
    this.markFormDirty(this.addItemForm);
    if (this.addItemForm.valid) {
      this.isLoading = true;
      const item = this.addItemForm.getRawValue();

      this.httpService.post<TrainComponent>('/api/train-components', item).subscribe({
        next: (result) => {
          this.notificationService.showSuccess('Train component successfully created');
          this.isLoading = false;
          this.success.emit(result);
        },
        error: _ => this.isLoading = false
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
