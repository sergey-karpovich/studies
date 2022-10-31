export default {
    async registerCoach(context, coach) {
        const userId = context.rootGetters.userId;
        const coachData={            
            firstName: coach.firstName,
            lastName: coach.lastName,
            description: coach.description,
            hourlyRate: coach.hourlyRate,
            areas: coach.areas,
        };

        const token = context.rootGetters.token;

        const response = await fetch(
            `https://vue-http-demo-d6e2b-default-rtdb.europe-west1.firebasedatabase.app/coaches/${userId}.json?auth=`+
            token,
        {
            method: 'PUT',
            body: JSON.stringify(coachData)
        });

        const responseData = await response.json();

        if(!response.ok){
            const error = new Error(responseData.message || 'Failed to fetch!');
            throw error;
        }

        context.commit('registerCoach',{
            ...coachData,
            id: userId
        });
    },
    async loadCoaches(context, payload) {
        if(!payload.forceRefresh && !context.getters.shouldUpdate){
            return;
        }
        
        const response = await fetch(
            `https://vue-http-demo-d6e2b-default-rtdb.europe-west1.firebasedatabase.app/coaches.json`
        );
        const responseData = await response.json();

        if(!response.ok){
            const error = new Error(responseData.message || 'Failed to fetch!');
            throw error;
        }

        const coaches = [];

        for (const key in responseData){
            const coach ={
                id: key,
                firstName: responseData[key].firstName,
                lastName: responseData[key].lastName,
                description: responseData[key].description,
                hourlyRate: responseData[key].hourlyRate,
                areas: responseData[key].areas,
            };
            coaches.push(coach);
        }

        context.commit('setCoaches', coaches);
        context.commit('setFetchTimestamp');
    }
}