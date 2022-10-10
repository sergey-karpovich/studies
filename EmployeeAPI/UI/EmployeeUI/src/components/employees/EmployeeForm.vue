<template>
    <div class="content">
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
                <img :src="PhotoPath+PhotoFileName" alt="photo" width="100" height="100" />
                <input type="file" @change="imageUpload">
            </div>
            <p v-if="!formIsValid">Please fix the above errors and submit again.</p>
            <div class="buttons">
                <base-button >Register</base-button>
                <base-button class="close" mode="outline" @click="closeForm">Close</base-button>
            </div>
        </form>
    </div>

</template>

<script>
export default {
    emits: ['submit-employee'],
    data() {
        return {
            PhotoPath: this.$store.state.PHOTO_URL,
            PhotoFileName: '',

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
                val: new Date(),
                isValid: true
            },
            hireDate: {
                val: new Date(),
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
                hireDate: this.hireDate.val
            };

            // this.$emit('submit-employee', formData);
            console.log(formData);
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
            this.axios.post(
                this.$store.state.API_URL + "employee/savefile",
                formData)
                .then((response) => {
                    this.PhotoFileName = response.data;
                });
        },
        closeForm(){
            return this.$emit('close');
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

