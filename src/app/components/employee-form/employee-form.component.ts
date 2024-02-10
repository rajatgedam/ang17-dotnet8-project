import { Component, inject } from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, FormsModule,ReactiveFormsModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent {
  formBuilder = inject(FormBuilder);
  employeeForm=this.formBuilder.group({
    name:['',[Validators.required]],
    email:['',[Validators.required, Validators.email]],
    age:[0,[Validators.required]],
    phone:['',[]],
    salary:[0,[Validators.required]],
  });


  saveEmployee(){
    console.log(this.employeeForm.value)

  }
}
