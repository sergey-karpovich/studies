export default {
    async contactCoach(context,payload){
        const newRequest={ 
            userEmail: payload.email,
            message: payload.message,
        };

        const response = await fetch(
            `https://vue-http-demo-d6e2b-default-rtdb.europe-west1.firebasedatabase.app/requests/${payload.coachId}.json`,
            {
                method: 'POST',
                body: JSON.stringify(newRequest)
            }
        );

        const responseData = await response.json();

        newRequest.id=responseData.name;
        newRequest.coachId = payload.coachId;

        if(!response.ok){
            const error = new Error(responseData.message || 'Failed to send request!');
            throw error;
        }

        context.commit('addRequest', newRequest);
    },

    async loadRequests(context){
        const userId = context.rootGetters.userId;
        const token = context.rootGetters.token;
        const response = await fetch(
            `https://vue-http-demo-d6e2b-default-rtdb.europe-west1.firebasedatabase.app/requests/${userId}.json?auth=`+
            token);
        const responseData = await response.json();

        if(!response.ok){
            const error =new Error (responseData.message || 'Failed to fetch request!');
            throw error;
        }

        const requests=[];

        for (const key in responseData){
            const request={
                id: key,
                coachId: userId,
                userEmail: responseData[key].userEmail,
                message: responseData[key].message,
            };
            requests.push(request);
        }
        context.commit('loadRequests', requests);        
    }
}