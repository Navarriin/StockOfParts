import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { PartsInterface } from '../../interfaces/parts.interface';
import { ActivatedRoute, Router } from '@angular/router';
import {
  FormControl,
  FormGroup,
  NonNullableFormBuilder,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss',
})
export class FormComponent {
  protected verify!: boolean;
  protected id!: number | null;

  protected registerPart: FormGroup<{
    partsName: FormControl<string>;
    machineName: FormControl<string>;
    quantity: FormControl<number>;
    price: FormControl<number>;
  }>;

  constructor(
    private router: Router,
    private api: ApiService,
    private route: ActivatedRoute,
    private formBuilder: NonNullableFormBuilder
  ) {
    this.route.params.subscribe((param) => {
      if (param['id']) {
        this.verify = true;
        this.id = +param['id'];
      } else {
        this.verify = false;
        this.id = null;
      }
    });

    this.registerPart = this.formBuilder.group({
      partsName: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(70),
        ],
      ],
      machineName: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(70),
        ],
      ],
      quantity: [0, [Validators.required, Validators.min(0)]],
      price: [0, [Validators.required, Validators.min(0.1)]],
    });

    if (this.id) {
      this.getPartById();
    }
  }

  getPartById(): void {
    this.api.getPartById(this.id!).subscribe({
      next: (data) => {
        this.registerPart.setValue({
          partsName: data.partsName,
          machineName: data.machineName,
          quantity: data.quantity,
          price: data.price,
        });
      },
      error: (err) => console.log(err),
    });
  }

  onSubmit(): void {
    if (this.registerPart.valid) {
      const value = this.registerPart.value as PartsInterface;
      this.api.addNewPart(value).subscribe({
        next: () => {
          this.router.navigate(['/list']);
        },
        error: (err) => console.log(err),
      });
    }
  }

  onEdit(): void {
    if (this.registerPart.valid && this.id !== null) {
      const value = this.registerPart.value as PartsInterface;
      const updatedValue = { ...value, id: this.id };
      this.api.updatePart(updatedValue).subscribe({
        next: () => {
          this.router.navigate(['/list']);
        },
        error: (err) => console.log(err),
      });
    }
  }

  onCancel(): void {
    this.registerPart.reset();
    this.router.navigate(['list']);
  }
}
