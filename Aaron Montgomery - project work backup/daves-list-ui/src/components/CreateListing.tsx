import React, { useState } from "react";

function CreateListing(props) {
    
    const [title, setTitle] = useState('');
    const [post, setPost] = useState('');

    const handleSubmit = (event) => {

        event.preventDefault();
        
        props.postAddPostRequest(props.httpService.axios, props.configurationService.appConfig, title, post)
            .then(() => props.setIsPostsUpdated({ value: !props.getIsPostsUpdated }));
        
        setTitle('');
        
        setPost('');
    }

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="title">{props.label}</label>
                <input
                    type="text"
                    id="title"
                    name="title"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    required
                />
            </div>

            <div>
                <label htmlFor="post">Post:</label>
                <input
                    type="text"
                    id="post"
                    name="post"
                    value={post}
                    onChange={(e) => setPost(e.target.value)}
                    required
                />
            </div>
            
            <div>
                <button type="submit">Submit</button>
            </div>
        </form>
    );
}

export default CreateListing;
