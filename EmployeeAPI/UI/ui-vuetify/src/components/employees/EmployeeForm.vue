<template>
    <v-form
    ref="form"
    v-model="valid"
    lazy-validation
    @submit.prevent="submitForm"
  >
    <v-text-field
        v-model.trim="firstName.val"
      :counter="20"
      :rules="nameRules"
      label="First Name"
      required
    ></v-text-field>
    <v-text-field
        v-model.trim="lastName.val"
      :counter="20"
      :rules="nameRules"
      label="Last Name"
      required
    ></v-text-field>

    <v-text-field
        v-model.trim="description.val"
      :rules="nameRules"
      label="Description"
      required
    ></v-text-field>

    <v-text-field
        v-model.number="rate.val"
      :rules="number"
      label="Hour rate"      
    ></v-text-field>

    <v-card>
    <v-container fluid>
      <v-row
        align="center"
      >
        <v-col cols="12">
          <v-autocomplete
            v-model="areas.val"
            :items="items"
            outlined
            dense
            chips
            small-chips
            label="Outlined"
            multiple
          ></v-autocomplete>
        </v-col>
        
      </v-row>
    </v-container>
  </v-card>
  <div class="form-control">
                <label for="birthDate">Birth date</label>
                <input type="date" id="birthDate" v-model="birthDate.val" />
            </div>
            <div class="form-control">
                <label for="hireDate">Hire date</label>
                <input type="date" id="hireDate" v-model="hireDate.val" />
            </div>
            <div class="form-control">
                <label for="phoneNumber">Phone number</label>
                <input type="tel" id="phoneNumber" v-model.number="phoneNumber.val" />
            </div>

    <div class="form-control">
        <img :src="imageURL" alt="photo" width="100" height="100" />
        <input type="file" @change="imageUpload">
    </div>
    <p v-if="!formIsValid">Please fix the above errors and submit again.</p>
    <v-btn
        v-if="id!=0"
        :disabled="!valid"
        color="success"
        class="mr-4"
        @click="submitForm"
    >
        Update
    </v-btn>
    <v-btn
        v-else
      :disabled="!valid"
      color="success"
      class="mr-4"
      @click="submitForm"
    >
        Register
    </v-btn>

    <v-btn
      color="warning"
      @click="closeForm"
    >
      Close form
    </v-btn>
  </v-form>
    <!-- <div class="content">
        <form @submit.prevent="submitForm">
            <div class="form-control" :class="{invalid: !firstName.isValid}">
                <label for="firstName">First Name</label>
                <input type="text" id="firstName" v-model.trim="firstName.val" @blur="clearValidity('firstName')" />
                <p v-if="!firstName.isValid">First name must not be empty.</p>
            </div>
            <div class="form-control" :class="{invalid: !lastName.isValid}">
                <label for="lastName">Last Name</label>
                <input type="text" id="lastName" v-model.trim="lastName.val" @blur="clearValidity('lastName')" />
                <p v-if="!lastName.isValid">Last name must not be empty.</p>
            </div>
            <div class="form-control" :class="{invalid: !description.isValid}">
                <label for="description">Description</label>
                <textarea id="description" rows="2" v-model.trim="description.val"
                    @blur="clearValidity('description')"></textarea>
                <p v-if="!description.isValid">Description must not be empty.</p>
            </div>
            <div class="form-control" :class="{invalid: !rate.isValid}">
                <label for="rate">Hourly Rate</label>
                <input type="number" id="rate" v-model.number="rate.val" @blur="clearValidity('rate')" />
                <p v-if="!description.isValid">Description must not be empty.</p>
            </div>
            <div class="form-control" :class="{invalid: !areas.isValid}">
                <h3>Areas of Expertise</h3>
                <div>
                    <input type="checkbox" id="frontend" value="frontend" v-model="areas.val"
                        @blur="clearValidity('areas')">
                    <label for="frontend">Frontend Development</label>
                </div>
                <div>
                    <input type="checkbox" id="backend" value="backend" v-model="areas.val"
                        @blur="clearValidity('areas')">
                    <label for="backend">Backend Development</label>
                </div>
                <div>
                    <input type="checkbox" id="deployment" value="deployment" v-model="areas.val"
                        @blur="clearValidity('areas')">
                    <label for="deployment">Deployment specialist</label>
                </div>
                <div>
                    <input type="checkbox" id="others" value="others" v-model="areas.val"
                        @blur="clearValidity('areas')">
                    <label for="others">Others </label>
                </div>
                <p v-if="!areas.isValid">At least one expertise must be checked.</p>
            </div>
            <div class="form-control">
                <label for="birthDate">Birth date</label>
                <input type="date" id="birthDate" v-model="birthDate.val" />
            </div>
            <div class="form-control">
                <label for="hireDate">Hire date</label>
                <input type="date" id="hireDate" v-model="hireDate.val" />
            </div>
            <div class="form-control">
                <label for="phoneNumber">Phone number</label>
                <input type="tel" id="phoneNumber" v-model.number="phoneNumber.val" />
            </div>
            <div class="form-control">
                <img :src="imageURL" alt="photo" width="100" height="100" />
                <input type="file" @change="imageUpload">
            </div>
            <p v-if="!formIsValid">Please fix the above errors and submit again.</p>
        </form>
        <div class="buttons">
            <base-button @click="submitForm" v-if="id">Update</base-button>
            <base-button @click="submitForm" v-else>Register</base-button>
            <base-button mode="outline" @click="closeForm">Close</base-button>
        </div>
    </div> -->

</template>

<script>
import axios from 'axios';
export default {
    props:['id'],
    emits: ['submit-employee', 'close'],
    data() {
        return {
            PhotoPath: this.$store.state.PHOTO_URL,
            PhotoFileName: 'anonymous.png',
            items: ['frontend', 'backend', 'deploying specialist', 'others'],
      
      
            employee: null,
            firstName: {
                val: '',
                isValid: true
            },
            lastName: {
                val: '',
                isValid: true
            },
            description: {
                val: '',
                isValid: true
            },
            rate: {
                val: null,
                isValid: true
            },
            areas: {
                val: [],
                isValid: true
            },
            birthDate: {
                val: null,
                isValid: true
            },
            hireDate: {
                val: null,
                isValid: true
            },
            phoneNumber: {
                val: null,
                isValid: true
            },
            photoPath: {
                val: '',
                isValid: true
            },
            formIsValid: true,
        };
    },

    methods: {
        formatDate (date) {
            let d = new Date(date);
            let month = (d.getMonth() + 1).toString();
            let day = d.getDate().toString();
            let year = d.getFullYear();
            if (month.length < 2) {
                month = '0' + month;
            }
            if (day.length < 2) {
                day = '0' + day;
            }
            return [year, month, day].join('-');
        },

        clearValidity(input) {
            this[input].isValid = true;
        },
        submitForm() {
            this.validateForm();

            if (!this.formIsValid) {
                return;
            }

            const formData = {
                firstName: this.firstName.val,
                lastName: this.lastName.val,
                description: this.description.val,
                hourlyRate: this.rate.val,
                areas: this.areas.val,
                birthDate: this.birthDate.val,
                hireDate: this.hireDate.val,
                phoneNumber: this.phoneNumber.val,
                photoPath: this.photoPath.val,
            };
            if(this.id){
                formData.EmployeeId=this.id;
            }
           this.$emit('submit-employee', formData);
        },
        validateForm() {
            this.formIsValid = true;
            if (this.firstName.val === '') {
                this.firstName.isValid = false;
                this.formIsValid = false;
            }
            if (this.lastName.val === '') {
                this.lastName.isValid = false;
                this.formIsValid = false;
            }
            if (this.description.val === '') {
                this.description.isValid = false;
                this.formIsValid = false;
            }
            if (!this.rate.val || this.rate.val < 0) {
                this.rate.isValid = false;
                this.formIsValid = false;
            }
            if (this.areas.val.length === 0) {
                this.areas.isValid = false;
                this.formIsValid = false;
            }
        },
        imageUpload(event){
            let formData=new FormData();
            formData.append('file',event.target.files[0]);
            axios.post(
                this.$store.state.API_URL+"/employee/savefile",
                formData)
                .then((response)=>{
                    this.photoPath.val=response.data;
                    this.PhotoFileName=response.data;
                });
        },
        closeForm(){
            return this.$emit('close');
        }, 
       
    },
    computed:{
        imageURL(){
            return  this.PhotoPath+this.PhotoFileName;
        }
    },
     created(){
        if(this.id){
            this.employee =  this.$store.state.employee.employees.find(emp=>emp.EmployeeId==this.id);
        }  
    },
    beforeMount(){
        if(this.id!=0){
            console.log(this.id);
            this.firstName.val= this.employee.firstName;
            this.lastName.val= this.employee.lastName;
            this.description.val= this.employee.description;
            this.rate.val= +this.employee.rate;
            this.areas.val= this.employee.areas.split(',');
            this.birthDate.val = this.formatDate(this.employee.birthDate);
            this.hireDate.val= this.formatDate(this.employee.hireDate);
            this.phoneNumber.val= +this.employee.phoneNumber;
            this.photoPath.val= this.employee.photoPath;
        }        
    }
}
</script>

<style scoped>

.content {
   
}
.form-control {
    margin: 0.1rem 0;
}

label {
    font-weight: bold;
    display: block;
    margin-bottom: 0.5rem;
}

input[type='checkbox']+label {
    font-weight: normal;
    display: inline;
    margin: 0 0 0 0.5rem;
}

input,
textarea {
    display: block;
    width: 100%;
    border: 1px solid #ccc;
    font: inherit;
}

input:focus,
textarea:focus {
    background-color: #f0e6fd;
    outline: none;
    border-color: #3d008d;
}

input[type='checkbox'] {
    display: inline;
    width: auto;
    border: none;
}

input[type='checkbox']:focus {
    outline: #3d008d solid 1px;
}

h3 {
    margin: 0.1rem 0;
    font-size: 1rem;
}

.invalid label {
    color: red;
}

.invalid input,
.invalid textarea {
    border: 1px solid red;
} 
.buttons{
    display: flex;
    justify-content: space-between;    
}
</style>

