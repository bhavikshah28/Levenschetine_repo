# Levenschetine_repo

This application is for assignment purpose. It is developed based on following requirements.


<b>Problem statement</b><br/>

You are required to create SPA and web APIs for finding the Levenshtein distance (LD) between two strings.


<b>Data Validation Specifications</b><br/>
<ul>
<li>All validation checks have to be implemented on both front-end and API side.</li>
<li>Identify, list and implement all possible necessary checks.</li>
</ul>

<b>Technical specifications</b>
<ul>
<li>API needs to be REST-based Web API using JSON for data transfer.</li>
<li>Calls have to be made over SSL. Or at least they need to be redirected to SSL.</li>
<li>We should be able to access the API with POSTMAN/Fiddler. But kindly protect the API with authorization token of your choice.</li>
<li>The web interface should allow the user to enter two strings and on submitting the same, the calculated distance should be stored in local/session storage.</li>
</ul>

Api would be accessbile by https://localhost:44370/ using below inputs:

{
  "FirstInput" : "Honda",
  "SecondInput": "Hyundai"
}
**SecretKey:** 0X67YT-FG4578-HJ3421-AD5643

in Ui , both input is validated on front side as well as backend side.

<b>Steps to run appication:</b>

1) Open the solution of Levenschentine.
2) Buid the Solution and run Angular project by ging clientapp project in cmd and run ng serve , so ANgular project will be run on 4200 port.
3) F5 the application, .Net core project would be run on browser with finding levenschentine distance and matrix.

![levenscheitine](https://user-images.githubusercontent.com/52338464/124021887-b9b2dd80-da09-11eb-928c-3fcf411adc93.png)

