import {
  ValidatorFn,
  ValidationErrors,
  AbstractControl,
} from '@angular/forms';

export const DateInPastValidator: ValidatorFn = (
  control: AbstractControl
): ValidationErrors | null => {
  const selectedDate: Date = new Date(control.value);
  const currentDate: Date = new Date(Date.now());

  if (selectedDate >= currentDate) {
    return { dateInPast: true };
  }

  return null;
};
