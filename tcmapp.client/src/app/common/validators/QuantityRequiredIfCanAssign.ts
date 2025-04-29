import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function QuantityRequiredIfCanAssign(canAssignControlName: string): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const parent = control.parent;
    if (!parent) return null;

    const canAssign = parent.get(canAssignControlName)?.value;
    const quantityValue = control.value;

    if (canAssign && (quantityValue === null || quantityValue === '')) {
      return { requiredWhenCanAssign: true };
    }

    return null;
  };
}
