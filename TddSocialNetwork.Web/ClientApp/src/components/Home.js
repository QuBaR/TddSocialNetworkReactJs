import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'
import ReactTimeAgo from 'react-time-ago'

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { posts: [], loading: true };
    }

    componentDidMount() {
        this.populatePosts();
    }

    static renderPosts(posts) {
        return (
                <div>
                    {posts.map(post =>
                        <div className='card'>
                            <img className='card-img-top' />
                            <div className='card-body'>
                                <h5 className='card-title'>{post.user.name}</h5>
                                <p className='card-text'>{post.message}</p>
                                <p class="card-text">
                                    <small class="text-muted">
                                        <ReactTimeAgo date={post.created} locale="en-US" />
                                    </small>
                                </p>
                            </div>
                        </div>
                    )}
                </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderPosts(this.state.posts);
        return (
            <div className="row">
                <div className="col-12">
                    <h1 id="tabelLabel" >Posts feed</h1>
                    <p>This component demonstrates fetching data from the server.</p>
                    {contents}
                </div>
            </div>
        );
    }



    async populatePosts() {
        const token = await authService.getAccessToken();
        const response = await fetch('wall/posts', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ posts: data, loading: false });
    }
}
