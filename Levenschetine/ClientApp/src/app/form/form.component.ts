import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";

import {AlgoApiService} from "../core/algo-api.service";
import {IForm} from '../core/interfaces/IForm';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  myForm: FormGroup;
  firstInput = new FormControl('', [Validators.required, Validators.maxLength(50)]);
  secondInput= new FormControl('', [Validators.required, Validators.maxLength(50)]);

  constructor(public fb: FormBuilder, private algoApiService: AlgoApiService) { }

  ngOnInit(): void {
    this.reactiveForm()
  }

    getApiData = (formInputsObj:IForm) =>{
    this.algoApiService.sendPostRequest(formInputsObj).subscribe(data => {
      this.algoApiService.updateApiData(data);
    })
  }

  /* Reactive form */
  reactiveForm = () => {
    this.myForm = this.fb.group({
      firstInput: this.firstInput,
      secondInput: this.secondInput,
    })
  }

  errorHandling = (control: string, error: string) => {
    console.log(error)
    return this.myForm.controls[control].hasError(error);
  }
  
  submitForm = () => {
    const formInputsObj: IForm ={
      FirstInput : this.myForm.value.firstInput,
      SecondInput : this.myForm.value.secondInput,
    }

    return this.getApiData(formInputsObj);
  }

}
