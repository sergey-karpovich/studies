<template>
    <v-dialog max-width="600px" v-model="dialog">
        <v-btn flat  slot="activator" class="success">Add new project</v-btn>
        <v-card>
            <v-card-title>
                <h2>Add a New Project</h2>
            </v-card-title>
            <v-card-text>
                <v-form class="px-3" ref="form">
                    <v-text-field label="Title" v-model="title" 
                    prepend-icon="folder" :rules="inputRules"></v-text-field>
                    <v-textarea label="Information" v-model="content"
                    prepend-icon="edit" :rules="inputRules"></v-textarea>

                    <v-menu>
                        <v-text-field :value="formattedDate"  slot="activator" 
                        label="Due date" prepend-icon="date_range"
                        :rules="inputRules"></v-text-field>
                        <v-date-picker v-model="due"></v-date-picker>
                    </v-menu>

                    <v-spacer></v-spacer>

                    <v-btn flat class="success mx-0 mt-3"
                    @click="submit"
                    :loading="loading">Add project                        
                    </v-btn>
                </v-form>
            </v-card-text>
        </v-card>
    </v-dialog>
</template>

<script>
import { format } from 'date-fns';
import  db  from '@/fb.js';
import { collection, addDoc } from "firebase/firestore";
export default {
    emits:['projectAdded'],
    data(){
        return {
            title:'',
            content:'',
            due: null,
            inputRules:[
                v =>v.length>=3 || 'Minimum length is 3 characters',

            ],
            loading: false,
            dialog: false,
        }
    },
    methods:{
        async submit(){
            if(this.$refs.form.validate()){
                this.loading = true;
                const project ={
                    title: this.title,
                    content: this.content,
                    due: format(new Date(this.due), 'do MMM yyyy'),
                    person: 'The Net Ninja',
                    status: 'ongoing',
                }

                // db.collection('projects').add(project).then(()=>{
                //     console.log('added to db');
                // })

                // const docRef=addDoc(collection(db, "projects"), project).then(()=>{
                //     console.log('added to db');
                //     console.log("Document written with ID: ", docRef.id)
                // });

                try {
                    const docRef = await addDoc(collection(db, "projects"), project);
                    // console.log("Document written with ID: ", docRef.id);
                    this.$emit('projectAdded');
                } catch (e) {
                    console.error("Error adding document: ", e);
                }
                this.loading=false;
                this.dialog = false;
            }
        }
    },
    computed:{
        formattedDate(){
            return this.due ? format(new Date(this.due), 'do MMM yyyy') :'';
        }
    }
}
</script>