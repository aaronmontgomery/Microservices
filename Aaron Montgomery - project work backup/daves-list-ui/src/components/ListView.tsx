import React, { useEffect, useState } from "react";

function ListView(props) {
    
    const [posts, setPosts] = useState([]);
  
    useEffect(() => {
        const getPosts = async () => {
            const posts = await props.getPostsRequest(props.httpService.axios, props.configurationService.appConfig);
            setPosts(posts.data);
        };
        
        //if (props.isLoggedIn) {
            getPosts();
        //}
    }, [props])
    
    return (
        <>
        {posts.flatMap(x =>
            <div key={x['id']}>
                <div>{x['title']}</div>
                <div>{x['post']}</div>
            </div>
        )}
        </>
    );
}

export default ListView;
