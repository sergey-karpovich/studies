<template>
    <v-form ref="form" lazy-validation @submit.prevent="submitForm">
        <v-text-field v-model.trim="firstName.val" :counter="20" label="First Name" required :rules="nameRules">
        </v-text-field>
        <v-text-field v-model.trim="lastName.val" :counter="20" label="Last Name" required :rules="nameRules">
        </v-text-field>

        <v-text-field v-model.trim="description.val" label="Description" required></v-text-field>

        <v-label>{{ rate.val }}$/hour</v-label>
        <v-slider v-model="rate.val" :rules="rateRules" color="orange" label="Rate per hour" hint="Be honest" min="1"
            max="100" thumb-label></v-slider>

        <v-card>
            <v-container fluid>
                <v-row align="center">
                    <v-col cols="12">
                        <v-autocomplete v-model="areas.val" :items="items" outlined dense chips small-chips
                            label="Areas" multiple :rules="areasRules"></v-autocomplete>
                    </v-col>

                </v-row>
            </v-container>
        </v-card>

        <!-- Date pickers-->
        <template>
            <div>
                <v-menu  v-model="birth" :close-on-content-click="false" transition="scale-transition" offset-y
                    min-width="auto">
                    <template v-slot:activator="{ on, attrs }">
                        <v-text-field v-model="birthDate.val" label="Birthday date" prepend-icon="mdi-calendar" readonly
                            v-bind="attrs" v-on="on"></v-text-field>
                    </template>
                    <v-date-picker v-model="birthDate.val"
                        :max="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)"
                        min="1950-01-01" @change="saveBirth"></v-date-picker>
                </v-menu>
            </div>
        </template>
        <template>
            <div>
                <v-menu  v-model="hire" :close-on-content-click="false" transition="scale-transition" offset-y
                    min-width="auto">
                    <template v-slot:activator="{ on, attrs }">
                        <v-text-field v-model="hireDate.val" label="Hire date" prepend-icon="mdi-calendar" readonly
                            v-bind="attrs" v-on="on"></v-text-field>
                    </template>
                    <v-date-picker v-model="hireDate.val"
                        :max="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)"
                        min="1950-01-01" @change="saveHire"></v-date-picker>
                </v-menu>
            </div>
        </template>
        <div class="form-control">
            <label for="phoneNumber">Phone number</label>
            <input type="tel" id="phoneNumber" v-model="phoneNumber.val" />
        </div>

        <div class="form-control">
            <img :src="imageURL" alt="photo" width="100" height="100" />
            <input type="file" @change="imageUpload">
        </div>
        <p v-if="!formIsValid">Please fix the above errors and submit again.</p>
        <v-btn v-if="id != 0" color="success" class="mr-4" @click="submitForm">
            Update
        </v-btn>
        <v-btn v-else color="success" class="mr-4" @click="submitForm">
            Register
        </v-btn>

        <v-btn color="warning" @click="closeForm">
            Close form
        </v-btn>
    </v-form>
</template>

<script>
import axios from 'axios';
export default {
    props: ['id'],
    emits: ['submit-employee', 'close'],
    data() {
        return {           
            birth: false,
            hire: false,

            PhotoPath: this.$store.state.PHOTO_URL,
            PhotoFileName: 'anonymous.png',
            items: ['frontend', 'backend', 'deploying specialist', 'others'],
            nameRules: [
                v => !!v || 'Name is required',
                v => (v && v.length <= 20) || 'Name must be less than 10 characters',
            ],
            rateRules: [
                val => val > 5 && val < 100 || `I don't believe you!`,
            ],
            areasRules: [
                val => val.length > 0 || 'At least one area'
            ],

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
                val: 0,
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
                val: 'anonymous.png',
                isValid: true
            },
            formIsValid: true,
        };
    },

    methods: {        
        saveBirth(date) {
            this.birthDate.val = date;
        },
        saveHire(date){
            this.hireDate.val = date;
        },
        formatDate(date) {
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
                rate: this.rate.val,
                areas: this.areas.val,
                birthDate: this.birthDate.val,
                hireDate: this.hireDate.val,
                homePhone: this.phoneNumber.val,
                photoPath: this.photoPath.val,
            };
            if (this.id) {
                formData.employeeId = this.id;
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
        imageUpload(event) {
            let formData = new FormData();
            formData.append('file', event.target.files[0]);
            axios.post(
                this.$store.state.API_URL + "/employee/savefile",
                formData)
                .then((response) => {
                    this.photoPath.val = response.data;
                    this.PhotoFileName = response.data;
                });
        },
        closeForm() {
            return this.$emit('close');
        },

    },
    computed: {
        imageURL() {
            return this.PhotoPath + this.photoPath.val;
        }
    },

    beforeMount() {
        if (this.id != 0) {
            this.employee = this.$store.state.employee.employees.find(emp => emp.employeeId == this.id);
            if (!this.employee) return;
            this.firstName.val = this.employee.firstName;
            this.lastName.val = this.employee.lastName;
            this.description.val = this.employee.description;
            this.rate.val = +this.employee.rate;
            const areasTemp = this.employee.areas
            this.areas.val = areasTemp.includes(',') ? areasTemp.split(',') : [areasTemp];
            this.birthDate.val = this.formatDate(this.employee.birthDate);
            this.hireDate.val = this.formatDate(this.employee.hireDate);
            this.phoneNumber.val = this.employee.homePhone;
            this.photoPath.val = this.employee.photoPath;
        }
    }
}
</script>

<style scoped>
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

.buttons {
    display: flex;
    justify-content: space-between;
}
</style>

