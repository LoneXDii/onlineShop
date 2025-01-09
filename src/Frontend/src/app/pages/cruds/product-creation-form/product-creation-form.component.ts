import {Component, inject} from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators
} from '@angular/forms';
import {ProductsService} from '../../../data/services/products.service';
import {Router} from '@angular/router';
import {ProductFormComponent} from './components/product-form/product-form.component';

@Component({
  selector: 'app-product-creation-form',
  imports: [
    ReactiveFormsModule,
    ProductFormComponent
  ],
  templateUrl: './product-creation-form.component.html',
  styleUrl: './product-creation-form.component.css'
})
export class ProductCreationFormComponent {
  productsService = inject(ProductsService);
  router = inject(Router);

  form = new FormGroup({
    name: new FormControl<string | null>(null, Validators.required),
    price: new FormControl<number | null>(null, [Validators.required, Validators.min(1)]),
    quantity: new FormControl<number | null>(null, [Validators.required, Validators.min(0)]),
    image: new FormControl<File | null>(null),
    attributes: new FormControl<number[]>([], this.attributesValidator),
  });

  attributesValidator(control: AbstractControl): ValidationErrors | null {
    const attributes: number[] = control.value;

    if (attributes.length > 0 && attributes.every(attr => attr !== 0)) {
      return null;
    }

    return { invalidAttributes: true };
  }

  onSubmit(formData: FormData) {
    this.productsService.createProduct(formData)
      .subscribe(() => this.router.navigate(['/admin']));
  }
}
