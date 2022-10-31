// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getFirestore } from "firebase/firestore";
// import { getAnalytics } from "firebase/analytics";

// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyAr2iW--0oPo_VkgTcNOgMYJ6JvOFAVdN0",
  authDomain: "vuetify-66821.firebaseapp.com",
  projectId: "vuetify-66821",
  storageBucket: "vuetify-66821.appspot.com",
  messagingSenderId: "516956990041",
  appId: "1:516956990041:web:509aa92dcbbf3149c45f48",
  measurementId: "G-3HYPF99B6W"
};

// Initialize Firebase
// const analytics = getAnalytics(app);
const app = initializeApp(firebaseConfig);
const db = getFirestore(app);

// db.settings({ timestampsInSnapshots: true })

export default db
